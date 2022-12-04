using Refit;
using SupportRegister.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportRegister.WebSite.Interface
{
    public interface IRegisApp
    {
        [Get("/api/RegisterApplication/GetAllApp")]
        public Task<List<ApplicationViewModel>> GetAll();

        [Get("/api/RegisterApplication/GetAllRegis/{idUser}")]
        public Task<List<RegisterApplicationViewModel>> GetAllRegis(string idUser);

        [Get("/api/RegisterApplication/GetDetail/{id}")]
        public Task<ApplicationViewModel> GetDetail(int id);

        [Get("/api/Student/GetStudentApp/{userId}")]
        public Task<StudentAppViewModel> GetStudentApp(string userId);

        [Post("/api/RegisterApplication/Store")]
        public Task<int> Store(string content, string title, int id, string userId, int idRegis);

        [Post("/api/RegisterApplication/Submit")]
        public Task<int> Submit(string content, string title, int id, string userId, int idRegis);

        [Get("/api/RegisterApplication/Update/{id}")]
        public Task<RegisterApplicationViewModel> Update(int id);

        [Get("/api/RegisterApplication/Edit")]
        public Task<int> Edit(string content, string title, int id, string userId, int idStatus);

        [Post("/api/RegisterApplication/Cancel")]
        public Task<int> Cancel(int idRegis);

        [Post("/api/RegisterApplication/Receive")]
        public Task<int> Receive(int idRegis);
    }
}
