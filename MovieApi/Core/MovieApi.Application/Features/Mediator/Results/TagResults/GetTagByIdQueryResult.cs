using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Results.TagResults
{
    public class GetTagByIdQueryResult
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}
