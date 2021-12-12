using Dsc.Project.Domain.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsc.Project.Domain.Services
{
    public interface IEmailFooterService
    {


        Task<EmailFooterDto> GetFooter(string userName, string password);


    }
}
