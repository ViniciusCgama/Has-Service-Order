﻿using AutoMapper;
using OsDsII.api.Dtos.Customer;
using OsDsII.api.Models;

namespace OsDsII.api
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}