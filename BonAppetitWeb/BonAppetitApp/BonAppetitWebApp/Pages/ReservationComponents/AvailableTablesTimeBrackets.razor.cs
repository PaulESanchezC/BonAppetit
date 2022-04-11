﻿using BonAppetitWebApp.Pages.ReservationComponents.ViewModel;
using Microsoft.AspNetCore.Components;

using Services.RestaurantServices;

namespace BonAppetitWebApp.Pages.ReservationComponents;

public partial class AvailableTablesTimeBrackets
{
    #region Dependencies
    [Inject] private IRestaurantService _restaurantService { get; set; }
    [Parameter] public string RestaurantId { get; set; }
    #endregion

    private AvailableTablesTimeBracketsVm BracketsVm { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        BracketsVm.DateOfRequest = DateTime.Now;
        BracketsVm.DateOfRequestString = DateTime.Now.ToString("MM-dd-yyyy");
        BracketsVm.ForHowMany = 2;
        await GetBracketsAsync();
    }

    private async Task GetBracketsAsync()
    {
        BracketsVm.DateOfRequestString = BracketsVm.DateOfRequest.ToString("MM-dd-yyyy");

        var request = await _restaurantService.GetAllAvailableReservationBracketsForRestaurant(RestaurantId,BracketsVm.DateOfRequestString);
        BracketsVm.Brackets = request.ResponseObject!;

        var tempList = BracketsVm.Brackets.Where(br => br.Table.AmountOfSeats == BracketsVm.ForHowMany);

        foreach(var value in BracketsVm.Brackets.Where(table => !BracketsVm.SeatsAvailable.Contains(table.Table.AmountOfSeats)))
            BracketsVm.SeatsAvailable.Add(value.Table.AmountOfSeats);

        foreach (var bracket in tempList.SelectMany(bracket => bracket.TablesTimeBrackets.Where(timeBracket => !BracketsVm.AvailableBrackets.Contains(timeBracket.StartTime))))
            BracketsVm.AvailableBrackets.Add(bracket.StartTime);
    }
}
