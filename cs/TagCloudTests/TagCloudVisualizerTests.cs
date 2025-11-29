using System.Drawing;
using FluentAssertions;
using TagCloud;
using TagCloud.CoordinatesProviders;
using TagCloud.Visualizers;

namespace TagCloudTests;

public class TagCloudVisualizerTests
{
    private TagCloudVisualizer visualizer;
    private ICoordinatesProvider coordinatesProvider;
    private CircularCloudLayouter layouter;
    private Random random = new();

    [SetUp]
    public void SetUp()
    {
        var center = new Point(0, 0);
        visualizer = new TagCloudVisualizer();
        coordinatesProvider = new ArchimedesSpiral(center, 3, 1);
        layouter = new CircularCloudLayouter(center, coordinatesProvider);
    }
    
    [Test]
    public void DrawRectangles_ShouldSaveImageInPath_WhenCorrectPathIsProvided()
    {
        var rectangles = new List<Rectangle>();
        for (int i = 0; i < 175; ++i)
        {
            var rectangle = layouter.PutNextRectangle(new Size(random.Next(10, 100), random.Next(10, 100)));
            rectangles.Add(rectangle);
        }

        var savePath =
            $"{AppDomain.CurrentDomain.BaseDirectory}/{nameof(DrawRectangles_ShouldSaveImageInPath_WhenCorrectPathIsProvided)}.png";
        
        visualizer.DrawRectangles(rectangles.ToArray(), new Size(1920, 1080), 
            savePath);

        File.Exists(savePath).Should().Be(true);
    }
}