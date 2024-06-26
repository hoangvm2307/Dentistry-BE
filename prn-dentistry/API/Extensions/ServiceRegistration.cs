﻿using DentistryBusinessObjects;
using DentistryRepositories;
using DentistryServices;
using Firebase;

namespace prn_dentistry.API.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            services.AddScoped<IClinicService, ClinicService>();
            services.AddScoped<IClinicRepository, ClinicRepository>();

            services.AddScoped<IClinicOwnerService, ClinicOwnerService>();
            services.AddScoped<IClinicOwnerRepository, ClinicOwnerRepository>();

            services.AddScoped<IClinicScheduleService, ClinicScheduleService>();
            services.AddScoped<IClinicScheduleRepository, ClinicScheduleRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IDentistService, DentistService>();
            services.AddScoped<IBaseRepository<Dentist>, DentistRepository>();

            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            services.AddScoped<ITreatmentPlanService, TreatmentPlanService>();
            services.AddScoped<ITreatmentPlanRepository, TreatmentPlanRepository>();

            services.AddSingleton(provider =>
            {
                var bucketName = "prn-project-75959.appspot.com";
                return new FirebaseStorageService(bucketName);
            });
            return services;
        }
    }
}
