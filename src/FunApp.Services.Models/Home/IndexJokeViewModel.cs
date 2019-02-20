using AutoMapper;
using FunApp.Models;
using FunApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunApp.Services.Models.Home
{
    public class IndexJokeViewModel : IMapFrom<Joke>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            // configuration.CreateMap<Joke, IndexJokeViewModel>().ForMember(x => x.CategoryName, x => x.MapFrom(j => j.Category.Name))
        }

        public string HtmlContent // replace new line in html 
        {
            get
            {
                return this.Content.Replace("\n", "<br />\n");
            }
        }
    }
}
