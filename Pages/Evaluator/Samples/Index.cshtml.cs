using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RenderingRazorPartialViewExample.Views;

namespace RenderingRazorPartialViewExample.Pages.Evaluator.Samples;

public class Index (RazorViewToStringRenderer razorViewToStringRenderer) : PageModel
{
    public string[] SampleList { get; set; } = ["Sample1", "Sample2", "Sample3"];
    
    public async Task<IActionResult> OnGetAsync(int? filterSelect=null)
    {
        await Task.Delay(TimeSpan.FromMicroseconds(100));

        if (filterSelect is not null)
        {
            string[] customSamples = ["CustomSample1", "CustomSample2"];
            var html = new StringBuilder();

            foreach (var sample in customSamples)
            {
                var partialHtml = await razorViewToStringRenderer.RenderViewToStringAsync(
                    PartialViews.SampleViewPartial, sample);
                html.Append(partialHtml);
            }

            return Content(html.ToString(), "text/html");
        }

        return Page();
    }
}