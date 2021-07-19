using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
namespace KyivDigital.Business.Models
{
    public class PagedFeedResponse
    {
        [JsonPropertyName("feed")]
        public FeedData Feed { get; set; }


        public PagedFeedResponse ShallowCopy()
        {
            return (PagedFeedResponse)this.MemberwiseClone();
        }

        public PagedFeedResponse DeepCopy()
        {
            PagedFeedResponse copyItem = (PagedFeedResponse)this.MemberwiseClone();
            copyItem.Feed = new FeedData
            {
                Meta = new Meta
                {
                    Pagination = new Pagination
                    {
                        Count = Feed.Meta.Pagination.Count,
                        CurrentPage = Feed.Meta.Pagination.CurrentPage,
                        PerPage = Feed.Meta.Pagination.PerPage,
                        Total = Feed.Meta.Pagination.Total,
                        TotalPages = Feed.Meta.Pagination.TotalPages
                    }
                },
                Data = Feed.Data.Select(x => new FeedItemModel
                {
                    Id = x.Id,
                    Clickable = x.Clickable,
                    CreatedAt = x.CreatedAt,
                    Description = x.Description,
                    Icon = x.Icon,
                    IsRead = x.IsRead,
                    SubIcon = x.SubIcon,
                    Title = x.Title,
                    Type = x.Type,
                    ValueImg = x.ValueImg,
                    ValueSum = x.ValueSum,
                    ValueText = x.ValueText,
                    Payload = x.Payload != null ? new FeedPayload
                    {
                        Qr = x.Payload.Qr != null ? new QRCodeModel
                        {
                            Code = x.Payload.Qr.Code,
                            ExpireAt = x.Payload.Qr.ExpireAt,
                            Id = x.Payload.Qr.Id,
                            IsShared = x.Payload.Qr.IsShared,
                            IsUsed = x.Payload.Qr.IsUsed
                        } : null
                    } : null
                }).ToList()
            };
            return copyItem;
        }
    }
}