using Microsoft.AspNetCore.Mvc;
using Refit;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.WebSite.Interface
{
    public interface IRegisScore
    {
        [Get("/api/Year/GetYearNow")]
        public Task<List<YearSemesterViewModel>> GetAllYearNow();

        [Get("/api/Student/GetAllStudent/{userId}")]
        public Task<StudentViewModel> GetAllStudent(string userId);

        [Get("/api/RegisterScoreboard/GetAll/{id}")]
        public Task<List<RegisterScoreboardViewModel>> GetAllRegisScore(string id);

        [Post("/api/RegisterScoreboard/Cancel")]
        public Task<int> Cancel(int cancelId);

        [Post("/api/RegisterScoreboard/Receive")]
        public Task<int> Receive(int idRegis);

        [Post("/api/RegisterScoreboard/Create")]
        public Task<int> Create(string option, int yearstart_stu, int yearend_stu, int id_start, int id_end, int soluong, string userId);
    }
}
