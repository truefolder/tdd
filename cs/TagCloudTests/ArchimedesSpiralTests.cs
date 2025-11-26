using System.Drawing;
using FluentAssertions;
using TagCloud.CoordinatesProviders;

namespace TagCloudTests;

public class ArchimedesSpiralTests
{
    private ArchimedesSpiral archimedesSpiral;
    
    [Test]
    public void GetNextPoint_ShouldReturnPointInCenter_WhenCalledOnce()
    {
        var center = new Point(0, 0);
        archimedesSpiral = new ArchimedesSpiral(center, 1, 1);
        
        var point = archimedesSpiral.GetNextPoint();

        point.First().Should().Be(center);
    }
}