﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RentalMVC.Application.Interfaces;
using RentalMVC.Application.Services;
using RentalMVC.Application.ViewModels.Reservation;

namespace RentalMVC.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IReservationService, ReservationService>();
        services.AddTransient<IValidator<NewReservationVm>, NewReservationVmValidator>();
        return services;
    }
}
