using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MyStat.Models;
using System.Text.Encodings.Web;

namespace MyStat.TagHelpers
{
    [HtmlTargetElement("homeworks", Attributes = "hw-list", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class HwFormTagHelper : TagHelper
    {
        [HtmlAttributeName("hw-list")]
        public IEnumerable<HomeworkItem>? Homeworks { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            output.TagMode = TagMode.StartTagAndEndTag;

            if (Homeworks == null)
            {
                return;
            }

            output.AddClass("container", HtmlEncoder.Default);

            foreach (var item in Homeworks)
            {
                var tag = new TagBuilder("div")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                tag.AddCssClass("hwItem");

                var newTag = new TagBuilder("div")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                newTag.AddCssClass("forManipulations");

                var inputType = new TagBuilder("input type=\"button\"");

                inputType.AddCssClass("downloadButtons");

                inputType.Attributes.Add("name", "downloadButton");
                inputType.Attributes.Add("value", "↓");
                inputType.Attributes.Add("data-content", item.Content);
                inputType.Attributes.Add("data-title", item.Title);

                var newInputType = new TagBuilder("input type=\"button\"");

                newInputType.AddCssClass("removeButtons");

                newInputType.Attributes.Add("name", "removeButton");
                newInputType.Attributes.Add("value", "X");
                newInputType.Attributes.Add("data-id", item.Id.ToString());

                newTag.InnerHtml.AppendHtml(inputType);
                newTag.InnerHtml.AppendHtml(newInputType);
                newTag.Attributes.Add("data-sent", item.Sent.ToString());

                var titleTag = new TagBuilder("div");

                titleTag.AddCssClass("forTitle");

                titleTag.InnerHtml.Append($"TITLE: {item.Title}");

                var contentTag = new TagBuilder("div");

                contentTag.AddCssClass("forContent");

                contentTag.InnerHtml.Append($"CONTENT: {item.Content}");

                var sentTag = new TagBuilder("div");

                sentTag.AddCssClass("forDate");

                sentTag.InnerHtml.Append($"Sent: {item.Sent.ToShortDateString()}");

                tag.InnerHtml.AppendHtml(newTag);
                tag.InnerHtml.AppendHtml(titleTag);
                tag.InnerHtml.AppendHtml(contentTag);
                tag.InnerHtml.AppendHtml(sentTag);

                output.Content.AppendHtml(tag);
            }
        }
    }
}
