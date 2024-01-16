# OpenApi.AspNetCore

This package helps openapi swagger.json to have detailed enum information.

## Jtechs.OpenApi.AspNetCore

https://www.nuget.org/packages/Jtechs.OpenApi.AspNetCore

Base common file for the openapi helper. Add enum to have title and description to the swagger.json

## Jtechs.OpenApi.AspNetCore.Swashbuclke

https://www.nuget.org/packages/Jtechs.OpenApi.AspNetCore.Swashbuckle

Swashbuclke extension to add enum title and description in the $type section.

if you define following enum in C#

```
[DisplayNameForEnum("MLB League"), Description("MLB League names")]
public enum League
{
    [DisplayNameForEnum("American League"), Description("The American League of Professional Baseball Clubs, known simply as the American League (AL), is one of two leagues that make up Major League Baseball (MLB) in the United States and Canada.")]
    American = 1,

    [DisplayNameForEnum("National League"), Description("The National League of Professional Baseball Clubs, known simply as the National League (NL), is the older of two leagues constituting Major League Baseball (MLB) in the United States and Canada.")]
    National = 2,
}
```

You can use this nuget package and write following in your Program.cs

```
builder.Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<TitleAndDescriptionSchemaFilter>();
    options.SchemaFilter<EnumSchemaFilter>();
    options.UseAllOfToExtendReferenceSchemas();
});
```

## License
Apache License Version 2.0

See [LICENSE](https://github.com/J-Tech-Japan/OpenApi.AspNetCore/blob/main/LICENSE)

## Support
If you would like to support our Open Source Activity, you can do it from our [Sponsor Page](https://github.com/sponsors/J-Tech-Japan)

Copyright (c) 2024- J-Tech Japan
