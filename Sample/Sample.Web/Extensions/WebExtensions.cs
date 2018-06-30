using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Sample.Web.Extensions
{
    public static class WebExtensions
    {
        public static MvcHtmlString SampleTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var fieldName = ExpressionHelper.GetExpressionText(expression);
            var fullBindingName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(fieldName);
            var fieldId = TagBuilder.CreateSanitizedId(fullBindingName);

            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var value = metadata.Model;

            var htmlString = string.Format(@"
<div class='row'>
    <div class='col-md-3'><label>{1}<label></div>
    <div class='col-md-9'>
        <input type='text' id='{0}' name='{1}' value='{2}' class='form-control' v-model='{1}'/>
    </div>
</div>
<br/>
", fieldId, fullBindingName, value ?? "");

            #region TagBuilder
            /*
            TagBuilder tag = new TagBuilder("input");
            tag.Attributes.Add("name", fullBindingName);
            tag.Attributes.Add("id", fieldId);
            tag.Attributes.Add("type", "text");
            tag.Attributes.Add("value", value == null ? "" : value.ToString());
          

            var validationAttributes = html.GetUnobtrusiveValidationAttributes(fullBindingName, metadata);
            foreach (var key in validationAttributes.Keys)
            {
                tag.Attributes.Add(key, validationAttributes[key].ToString());
            }
 
            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
            */
            #endregion

            return new MvcHtmlString(htmlString);
        }

        public static MvcHtmlString SampleSubmitButton(this HtmlHelper html, string buttonText = "Kaydet")
        {
            var htmlString = string.Format(@"

<input type='submit' class='btn btn-success' value='{0}'></button>

", buttonText);

            return new MvcHtmlString(htmlString);
        }

        public static MvcHtmlString SampleVueInitializerFor<TModel>(this HtmlHelper html, TModel model)
        {
            var requiredDataFields = new StringBuilder();
            var requiredMainCheck = new StringBuilder();
            var requiredChecks = new StringBuilder();


            var t = model.GetType();
            foreach (var pi in t.GetProperties())
            {
                var hasRequired = Attribute.IsDefined(pi, typeof(RequiredAttribute));
                if (hasRequired)
                {
                    //data properties
                    var requiredDataFieldsLine = string.Format("{0}:null, ", pi.Name);
                    requiredDataFields.Append(requiredDataFieldsLine);

                    //...if check
                    requiredMainCheck.Append("this.");
                    requiredMainCheck.Append(pi.Name);
                    requiredMainCheck.Append(" && ");

                    //error pushes
                    var errorLine = string.Format(@"
           if (!this.{0}) {{
                this.errors.push('{0} required.');
              }}
", pi.Name);
                    requiredChecks.Append(errorLine);
                }


                var hasEmail = Attribute.IsDefined(pi, typeof(EmailAddressAttribute));
                //....
            }


            var htmlString = string.Format(@"
<script>
const app = new Vue({{
  el: '#app',
  data: {{
    errors: [],
{0}
  }},
  methods:{{
    checkForm: function (e) {{
      if ({1}) {{
        return true;
      }}
      
      this.errors = [];
      
     {2}
      
      e.preventDefault();
    }}
  }}
}})
</script>
", requiredDataFields, requiredMainCheck.ToString().Trim().TrimEnd('&').Trim(), requiredChecks);

            return new MvcHtmlString(htmlString);
        }

        public static MvcHtmlString SampleHeader(this HtmlHelper html)
        {
            var htmlString = @"<br/><br/><br/>";

            return new MvcHtmlString(htmlString);
        }
    }
}