using Jtechs.OpenApi.AspNetCore;
using System.ComponentModel;
[DisplayNameForEnum("MLB League"), Description("MLB League names")]
public enum League
{
    [DisplayNameForEnum("American League"), Description("The American League of Professional Baseball Clubs, known simply as the American League (AL), is one of two leagues that make up Major League Baseball (MLB) in the United States and Canada.")]
    American = 1,

    [DisplayNameForEnum("National League"), Description("The National League of Professional Baseball Clubs, known simply as the National League (NL), is the older of two leagues constituting Major League Baseball (MLB) in the United States and Canada.")]
    National = 2,
}