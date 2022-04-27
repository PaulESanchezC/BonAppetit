using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Models.TableModels;
using Services.TableServices;
using StaticData;

namespace BonAppetitManagerApp.Pages.TablesComponents;

[Authorize(Roles = Role.Manager)]
public partial class EditTable
{
    #region Dependencies

    [Parameter] public Table Table { get; set; } = new();
    [Parameter] public EventCallback<string> DeletedTableId { get; set; }
    [Inject] private ITableService _tableService { get; set; }
    [Inject] private IMapper _mapper { get; set; }

    #endregion

    private TableUpdate TableUpdate { get; set; } = new();

    protected override void OnInitialized()
    {
        Table.FrequencyOfReservation *= 60;
    }
    private async Task UpdateTableInformationAsync()
    {
        Table.FrequencyOfReservation /= 60;
        TableUpdate = _mapper.Map<TableUpdate>(Table);
        var request = await _tableService.UpdateTableAsync(TableUpdate);

        if (request.IsSuccessful)
            Table = request.ResponseObject!.FirstOrDefault()!;
        Table.FrequencyOfReservation *= 60;
    }
    private async Task DeleteTable()
    {
        var tableId = Table.TableId;
        var request = await _tableService.DeleteTableAsync(tableId);
        if (request.IsSuccessful)
            await DeletedTableId.InvokeAsync(tableId);
    }
}