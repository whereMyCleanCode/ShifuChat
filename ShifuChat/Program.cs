var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ShifuChat.DAL.IIdentity, ShifuChat.DAL.Identity>();
builder.Services.AddSingleton<ShifuChat.BL.IIdentityUser, ShifuChat.BL.IdentityUser>();
builder.Services.AddSingleton<ShifuChat.BL.CryptoPub.ICryptoWorker, ShifuChat.BL.CryptoPub.CryptoWorker>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

builder.Services.AddMvc();

///Injection and see you see me only tommorow
///
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors();
app.MapRazorPages();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

