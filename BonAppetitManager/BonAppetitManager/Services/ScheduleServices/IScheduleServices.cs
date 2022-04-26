using Models.DashboardVm.Schedules;
using Models.ResponseModels;
using Models.ScheduleModels;

namespace Services.ScheduleServices;

public interface IScheduleServices
{
    Task<Response<Schedule>> GetScheduleAsync();
    Task<Response<Schedule>> UpdateScheduleAsync(ScheduleUpdate scheduleToUpdate);

    Task<Schedule> MapScheduleVmToScheduleTask(SchedulesVm scheduleVm);
    Task<SchedulesVm> MapScheduleToScheduleVmTask(Schedule schedule);
}