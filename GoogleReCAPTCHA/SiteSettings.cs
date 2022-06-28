using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using PersonalSiteMVC;


namespace GoogleReCAPTCHA
{
    /* Implementing Google reCAPTCHA to stop automatic messages through the contact form */
    public static class SiteSettings
    {
        public const string GoogleReCaptchaSecurityKey = "6Le2bfwaAAAAAIPYg6AzjXt78dDhYXK2IWlnt2yX";
        public const string GoogleReCaptchaSiteKey = "6Le2bfwaAAAAALrbwx4QWEZzis6p0AV-9njItKLH";
    }

    /* Generate reCAPTCHA in views that use the above class values */
    public static class GoogleCaptchaHelper
    {
        public static IHtmlString GoogleCaptcha(this HtmlHelper helper)
        {
            const string publicSiteKey = SiteSettings.GoogleReCaptchaSiteKey;

            var mvcHtmlString = new TagBuilder("div")
            {
                Attributes =
                    {
                        new KeyValuePair<string, string>("class", "g-recaptcha"),
                        new KeyValuePair<string, string>("data-sitekey", publicSiteKey)
                    }
            };

            const string googleCaptchaScript = "<script src='https://www.google.com/recaptcha/api.js'></script>";
            var renderedCaptcha = mvcHtmlString.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create($"{googleCaptchaScript}{renderedCaptcha}");
        }
    }

    /* Show error message if reCAPTCHA is invalid for any reason */
    public static class InvalidGoogleCaptchaHelper
    {
        public static IHtmlString InvalidGoogleCaptchaLabel(this HtmlHelper helper, string errorText)
        {
            var invalidCaptchaObj = helper.ViewContext.Controller.TempData["InvalidCaptcha"];

            var invalidCaptcha = invalidCaptchaObj?.ToString();
            if (string.IsNullOrWhiteSpace(invalidCaptcha)) return MvcHtmlString.Create("");

            var buttonTag = new TagBuilder("span")
            {
                Attributes =
                    {
                        new KeyValuePair<string, string>("class", "text text-danger")
                    },
                InnerHtml = errorText ?? invalidCaptcha
            };

            return MvcHtmlString.Create(buttonTag.ToString(TagRenderMode.Normal));
        }
    }
}
