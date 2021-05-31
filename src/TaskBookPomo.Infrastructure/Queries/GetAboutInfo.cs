using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using TaskBookPomo.Common.Helpers;

namespace TaskBookPomo.Infrastructure.Queries
{
    public static class GetAboutInfo
    {
        public record Query : IRequest<AboutInfo>;

        [UsedImplicitly]
        public class Handler : IRequestHandler<Query, AboutInfo>
        {
            private readonly IAboutInfoHelper _aboutInfoHelper;

            public Handler(IAboutInfoHelper aboutInfoHelper)
            {
                _aboutInfoHelper = aboutInfoHelper;
            }

            public Task<AboutInfo> Handle(Query request, CancellationToken cancellationToken) =>
                Task.FromResult(result: _aboutInfoHelper.GetAboutInfo());
        }
    }
}