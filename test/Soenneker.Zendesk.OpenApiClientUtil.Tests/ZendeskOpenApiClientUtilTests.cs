using Soenneker.Zendesk.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Zendesk.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ZendeskOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IZendeskOpenApiClientUtil _openapiclientutil;

    public ZendeskOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IZendeskOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
