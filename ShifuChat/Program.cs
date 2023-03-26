var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ShifuChat.DAL.IIdentityDbContext, ShifuChat.DAL.IdentityDbContext>();
builder.Services.AddSingleton<ShifuChat.BL.IIdentityUser, ShifuChat.BL.IdentityUser>();
builder.Services.AddSingleton<ShifuChat.BL.CryptoPub.ICryptoWorker, ShifuChat.BL.CryptoPub.CryptoWorker>();
builder.Services.AddScoped<ShifuChat.BL.GiveMeUser.IRegesteredUser, ShifuChat.BL.GiveMeUser.RegesteredUser>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddMvc();
builder.Services.AddSession();

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
app.MapRazorPages();
app.UseStaticFiles();
app.UseSession();
app.UseAuthorization();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

