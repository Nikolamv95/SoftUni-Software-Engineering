namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Core.ViewModels.Orders.Create;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using System;
    using System.Globalization;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions

            ///From input -> create real object
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            ///from real object -> create view
            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Categories

            ///From input -> create real object
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            ///from real object -> create view
            this.CreateMap<Category, CategoryAllViewModel>()
               .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Employees
            ///Mapping the real model with the view model
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PositionName, y => y.MapFrom(z => z.Name));

            ///From input -> create real object
            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            ///from real object -> create view
            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position.Name));

            //Items
            ///Mapping the real model with the view model
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Name));

            ///From input -> create real object
            this.CreateMap<CreateItemInputModel, Item>();

            ///from real object -> create view
            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category.Name));

            //Orders
            ///Mapping the real model with the view model
            this.CreateMap<Item, CreateOrderItemViewModel>()
                .ForMember(x => x.ItemId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ItemName, y => y.MapFrom(z => z.Name));

            this.CreateMap<Employee, CreateOrderEmployeeViewModel>()
                .ForMember(x => x.EmployeeId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.EmployeeName, y => y.MapFrom(z => z.Name));

            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(x => x.DateTime, y => y.MapFrom(z => DateTime.UtcNow))
                .ForMember(x => x.Type, y => y.MapFrom(z => OrderType.ToGo));

            this.CreateMap<CreateOrderInputModel, OrderItem>()
               .ForMember(x => x.ItemId, y => y.MapFrom(z => z.ItemId))
               .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity));

            this.CreateMap<Order, OrderAllViewModel>()
               .ForMember(x => x.Employee, y => y.MapFrom(z => z.Employee.Name))
               .ForMember(x => x.DateTime, y => y.MapFrom(z => z.DateTime
                                                            .ToString("D", CultureInfo.InvariantCulture)))
               .ForMember(x => x.OrderId, y => y.MapFrom(z => z.Id));
        }
    }
}
