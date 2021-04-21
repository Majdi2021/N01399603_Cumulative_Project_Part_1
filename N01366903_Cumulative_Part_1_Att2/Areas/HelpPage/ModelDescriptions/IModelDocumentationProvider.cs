using System;
using System.Reflection;

namespace N01366903_Cumulative_Part_1_Att2.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}