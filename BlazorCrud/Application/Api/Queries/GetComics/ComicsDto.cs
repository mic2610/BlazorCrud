using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Api.Queries.GetComics
{
    public class ComicsDto
    {
        public IList<Comic> Comics { get; set; }
    }
}
