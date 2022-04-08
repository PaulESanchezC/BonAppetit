using Models.TableModels;

namespace Models.TableReservationBracketsModels;

public class TableReservationBracketDto
{
    public TableDto Table { get; set; }
    public List<TableTimeBracketDto> TablesTimeBrackets { get; set; }
}