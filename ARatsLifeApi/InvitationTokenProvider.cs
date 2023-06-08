using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;

public class InvitationTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
{
  public InvitationTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<InvitationTokenProviderOptions> options, ILogger<DataProtectorTokenProvider<TUser>> logger) : base(dataProtectionProvider, options, logger)
  {

  }
}

public class InvitationTokenProviderOptions : DataProtectionTokenProviderOptions
{
}