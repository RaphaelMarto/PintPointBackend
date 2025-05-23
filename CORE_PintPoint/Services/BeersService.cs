﻿using CORE_PintPoint.Abstraction.IRepo;
using CORE_PintPoint.Abstraction.IService;
using CORE_PintPoint.Entities;
using Domain_PintPoint.Entities;

namespace CORE_PintPoint.Services
{
    public class BeersService : IBeersService
    {
        private readonly IBeersRepo _BeersRepo;
        private readonly IBeerTypeRepo _BeerTypeRepo;
        private readonly IBreweriesRepo _breweriesRepo;
        private readonly ICountriesRepo _countriesRepo;
        public BeersService(IBeersRepo beersRepo, IBeerTypeRepo beerTypeRepo, IBreweriesRepo breweriesRepo, ICountriesRepo countriesRepo)
        {
            _BeersRepo = beersRepo;
            _BeerTypeRepo = beerTypeRepo;
            _breweriesRepo = breweriesRepo;
            _countriesRepo = countriesRepo;
        }
        public OffsetResult<BeersWithNames> GetAll(int offset, int limit, string order, string type, string search)
        {
            OffsetResult<Beers> beers = _BeersRepo.Get(offset, limit, order, type, search);
            List<BeersWithNames> beersWithNames = beers.Results.Select(x => new BeersWithNames(x)).ToList();

            for (int i = 0; i < beersWithNames.Count(); i++)
            {
                beersWithNames[i].BeerTypeName = _BeerTypeRepo.Get(beersWithNames[i].IdBeerType).Name;
                Breweries breweries = _breweriesRepo.Get(beersWithNames[i].IdBrewery);
                beersWithNames[i].BreweryName = breweries.Name;

                Countries country = _countriesRepo.Get(breweries.IdCountry);
                beersWithNames[i].CountryName = country.Name;
                beersWithNames[i].FlagUrl = country.CountryFlagUrl; // _countriesRepo.GetFlag(beersWithNames[i].CountryName).Result;
            }

            return new OffsetResult<BeersWithNames>()
            {
                Results = beersWithNames,
                Total = beers.Total
            };
        }

        public BeersWithNames GetOne(int id, int idUser)
        {
            BeersWithNames beer = new BeersWithNames(_BeersRepo.GetOne(id, idUser));

            beer.BeerTypeName = _BeerTypeRepo.Get(beer.IdBeerType).Name;
            Breweries breweries = _breweriesRepo.Get(beer.IdBrewery);
            beer.BreweryName = breweries.Name;

            Countries country = _countriesRepo.Get(breweries.IdCountry);
            beer.CountryName = country.Name;
            beer.FlagUrl = country.CountryFlagUrl;

            return beer;
        }

        public bool Post(Beers beer)
        {
            return _BeersRepo.post(beer);
        }
    }
}
