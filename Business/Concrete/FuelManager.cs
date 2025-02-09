﻿using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Dtos.Fuel;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class FuelManager: IFuelService
{
    private readonly IFuelDal _fuelDal;
    private readonly FuelBusinessRules _fuelBusinessRules;
    private readonly IMapper _mapper;
    public FuelManager(IFuelDal fueldDal, FuelBusinessRules fuelBusinessRules, IMapper mapper)
    {
        _fuelDal = fueldDal;
        _fuelBusinessRules = fuelBusinessRules;
        _mapper = mapper;
    }

    public AddFuelResponse Add(AddFuelRequest request)
    {
        _fuelBusinessRules.CheckIfFuelNameNotExists(request.Name);
        Fuel fuelToAdd = _mapper.Map<Fuel>(request); 

        _fuelDal.Add(fuelToAdd);

        AddFuelResponse response = _mapper.Map<AddFuelResponse>(fuelToAdd);
        return response;
    }

    public GetFuelListResponse GetList(GetFuelListRequest request)
    {
        IList<Fuel> fuelList = _fuelDal.GetList();
        GetFuelListResponse response = _mapper.Map<GetFuelListResponse>(fuelList);
        return response;
    }

    public GetByIDFuelResponse GetById(int id)
    {
        _fuelBusinessRules.CheckIfFuelExists(id);
        Fuel? fuel = _fuelDal.GetList().First<Fuel>(b => b.Id == id);
        GetByIDFuelResponse response = _mapper.Map<GetByIDFuelResponse>(fuel);

        return response;
    }
    public DeleteFuelResponse Delete(DeleteFuelRequest request)
    {
        _fuelBusinessRules.CheckIfFuelExists(request.Id);
        Fuel DeleteFuel = _mapper.Map<Fuel>(request);
        _fuelDal.Delete(DeleteFuel);
        DeleteFuelResponse response = _mapper.Map<DeleteFuelResponse>(DeleteFuel);
        return response;
    }
    public UpdateFuelResponse Update(UpdateFuelRequest request)
    {
       
        _fuelBusinessRules.CheckIfFuelExists(request.Id);
        Fuel UpdateFuel = _mapper.Map<Fuel>(request);
        _fuelDal.Update(UpdateFuel);
        FuelUpdateDto dto = _mapper.Map<FuelUpdateDto>(UpdateFuel);
        UpdateFuelResponse response = _mapper.Map<UpdateFuelResponse>(dto);
        return response;
    }
}
