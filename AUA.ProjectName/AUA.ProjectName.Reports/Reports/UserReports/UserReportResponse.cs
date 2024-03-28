using AUA.Infrastructure.ReportInfra.Report;
using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AppUserAggregate;
using AutoMapper;

namespace AUA.ProjectName.Reports.Reports.UserReports
{
    public class UserReportResponse : IReportResponse, IHaveCustomMappings
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public UserContact UserContact { get; set; }

       public IEnumerable<string> UserNames { get; set; }

        public void ConfigureMapping(Profile configuration)
        {
            configuration.CreateMap<AppUser, UserReportResponse>()
               .ForMember(p => p.UserNames, p => p.MapFrom(q => q.UserAccounts.Select(r => r.UserName)));

        }
    }
}
