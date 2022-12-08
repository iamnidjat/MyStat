using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStat.Models;
using System.Text.Encodings.Web;

namespace MyStat.HtmlHelpers
{
    public static class HwFormHelper
    {
        public static HtmlString RenderHomeworks(this IHtmlHelper source, IEnumerable<HomeworkItem> homeworks)
        {
            var builder = new TagBuilder("div")
            {
                TagRenderMode = TagRenderMode.Normal
            };

            builder.AddCssClass("container");

            foreach (var item in homeworks)
            {
                var tag = new TagBuilder("div")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                tag.AddCssClass("hwItem");
                tag.GenerateId(item.Id.ToString(), "_");

                tag.Attributes.Add("data-item", homeworks.ToString());

                var newTag = new TagBuilder("div")
                {
                    TagRenderMode = TagRenderMode.Normal
                };

                newTag.AddCssClass("forManipulations");

                var inputType = new TagBuilder("input type=\"button\"");

                inputType.GenerateId("downloadButton", "_");

                inputType.Attributes.Add("name", "downloadButton");
                inputType.Attributes.Add("value", "↓");

                var newInputType = new TagBuilder("input type=\"button\"");

                newInputType.GenerateId("removeButton", "_");

                newInputType.Attributes.Add("name", "removeButton");
                newInputType.Attributes.Add("value", "X");
                newInputType.Attributes.Add("data-id", item.Id.ToString());

                newTag.InnerHtml.AppendHtml(inputType);
                newTag.InnerHtml.AppendHtml(newInputType);

                var contentTag = new TagBuilder("div");

                contentTag.AddCssClass("forContent");

                contentTag.Attributes.Add("data-title", item.Title);
                contentTag.Attributes.Add("data-content", item.Content);
                contentTag.InnerHtml.Append($"Title: {item.Title}");
                contentTag.InnerHtml.AppendLine();
                contentTag.InnerHtml.AppendLine();
                contentTag.InnerHtml.Append("Content:");
                contentTag.InnerHtml.AppendLine();
                contentTag.InnerHtml.Append($"{item.Content}");

                var sentTag = new TagBuilder("div");

                sentTag.AddCssClass("forDate");

                sentTag.Attributes.Add("data-sent", item.Sent.ToString());
                sentTag.InnerHtml.Append($"Sent: {item.Sent.ToShortDateString()}");

                tag.InnerHtml.AppendHtml(newTag);
                tag.InnerHtml.AppendHtml(contentTag);
                tag.InnerHtml.AppendHtml(sentTag);

                builder.InnerHtml.AppendHtml(tag);
            }

            using var writer = new StringWriter();

            builder.WriteTo(writer, HtmlEncoder.Default);

            return new HtmlString(writer.ToString());
        }
    }
}
