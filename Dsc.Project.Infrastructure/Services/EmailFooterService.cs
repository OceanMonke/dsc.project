using Dsc.Project.Domain.Data.Dto;
using Dsc.Project.Domain.Services;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsc.Project.Infrastructure.Services
{
    public class EmailFooterService : IEmailFooterService
    {
        private readonly ExchangeService _exchangeService;

        public EmailFooterService(ExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }




        public async Task<EmailFooterDto> GetFooter(string userName, string password)
        {
            _exchangeService.Credentials = new WebCredentials(userName, password);

            var config = await UserConfiguration.Bind(
                _exchangeService,
                "OWA.UserOptions", 
                WellKnownFolderName.Root,
                UserConfigurationProperties.Dictionary);

            var html  = config.Dictionary.ContainsKey("signaturehtml")
                ? config.Dictionary["signaturehtml"] as string
                : string.Empty;

            return new EmailFooterDto(html);
        }
    }
}
