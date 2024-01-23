
using Core.CrossCuttingConcers.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ExceptionMilddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMilddleware(RequestDelegate next)
    {
        //Delegate: Bir kod bütününü temsil eder.
        //RequestDelegate: Bir HTTP Request akışındaki bir sonraki adımı temsil eder.
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpcontext)
    {
        // HttpContext: Bir HTTP Request akışını temsil eder.
        // Asynchronous: Eş Zananlı.

        // Örnek olarak add endpoint metodundakini kodların referansını _next'tedir.
        try
        {
            await _next(httpcontext);
        }
        catch(Exception exception) 
        {
            await HandleExceptionAsync(httpcontext,exception);
        }

    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = MediaTypeNames.Application.Json; //"application/json";


      //  if(exception.GetType() == typeof(BusinessException)) { }// alttakiyle aynı işi yapar

        if(exception is BusinessException businessException) // is : tip olarak bu mu anlamında 
        {
            return createBusinessProblemDetailsResponse(httpContext, businessException);
        }
        return createProblemDetailsResponse(httpContext, exception);
    }

    private Task createBusinessProblemDetailsResponse(HttpContext httpContext ,BusinessException exception)
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        BusinessProblemDetails businessProblemDetails = new()
        {
            Title = "Business Exception",
            Type = "https://doc.RentAcar.com/business",
            Detail = exception.Message,
            Instance = httpContext.Request.Path
        };
        return httpContext.Response.WriteAsync(businessProblemDetails.ToString());
        
    }

    private Task createProblemDetailsResponse(HttpContext httpContext,Exception exception)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        ProblemDetails problemdetails= new()
        {
            Title = "Business Exception",
            Type = "https://doc.RentAcar.com/business",
            Detail = exception.Message,
            Instance = httpContext.Request.Path
        };
        return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(problemdetails));
    }
}
