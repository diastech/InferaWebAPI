using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using Infera_WebApi.Configuration;

namespace Infera_WebApi.Requests.Base
{
    public abstract class BaseRequest
    {
        [Range(1, 200)]
        public int PageSize { get; set; } = int.Parse(CustomConfig.AppSetting["Paging:DefaultPageSize"]);
        [Min(1)]
        public int PageNumber { get; set; } = int.Parse(CustomConfig.AppSetting["Paging:DefaultPageNumber"]);
        public int TotalRecords { get; set; } = int.Parse(CustomConfig.AppSetting["Paging:DefaultTotalRecords"]);
        public List<String>? Include { get; set; }=new List<String>();

        public int GetOffset()
        {
            int offset = (PageNumber - 1) * PageSize;
            if (offset > 0) return offset;
            return 0;
        }

        public int GetLimit()
        {
            return PageSize;
        }

    }
}
