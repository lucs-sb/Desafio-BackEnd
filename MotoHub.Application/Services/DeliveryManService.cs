using Mapster;
using Microsoft.AspNetCore.Identity;
using MotoHub.Application.Resources;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Application.Services;

public class DeliveryManService : IDeliveryManService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<UserAuth> _passwordHasher;
    private const string _filePath = "temp/files/";

    public DeliveryManService(IUnitOfWork unitOfWork, IPasswordHasher<UserAuth> passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task CreateAsync(DeliveryManDTO deliveryManDTO)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            UserAuth? user = await _unitOfWork.Repository<UserAuth>().GetByIdentifierAsync(deliveryManDTO.Identifier);

            if (user != null)
                throw new InvalidOperationException(string.Format(BusinessMessage.Invalid_Operation_Warning, "entregador"));

            user = deliveryManDTO.Adapt<UserAuth>();

            user.Password = _passwordHasher.HashPassword(user, deliveryManDTO.Password);

            try
            {
                if (!string.IsNullOrEmpty(deliveryManDTO.DriverLicenseImage))
                    SavePngOrBmpFromBase64(deliveryManDTO.DriverLicenseImage);
            }
            catch
            {
                //
            }

            await _unitOfWork.Repository<UserAuth>().AddAsync(user);

            DeliveryMan deliveryMan = deliveryManDTO.Adapt<DeliveryMan>();

            await _unitOfWork.Repository<DeliveryMan>().AddAsync(deliveryMan);

            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();

            throw;
        }
    }

    public async Task UpdateAsync(string identifier, string driverLicenseImage)
    {
        DeliveryMan deliveryMan = await _unitOfWork.Repository<DeliveryMan>().GetByIdentifierAsync(identifier) ?? throw new KeyNotFoundException(string.Format(BusinessMessage.NotFound_Warning, "entregador"));

        SavePngOrBmpFromBase64(driverLicenseImage);
    }

    private void SavePngOrBmpFromBase64(string base64)
    {
        byte[] fileBytes = Convert.FromBase64String(base64);

        bool isPng = fileBytes.Take(8).SequenceEqual(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A });

        bool isBmp = fileBytes.Take(2).SequenceEqual(new byte[] { 0x42, 0x4D });

        if (!isPng && !isBmp)
            throw new InvalidOperationException(BusinessMessage.Invalid_Image_Warning);

        string? folder = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(folder))
        {
            Directory.CreateDirectory(folder);
        }

        string extension = isBmp ? ".bmp" : ".png";

        File.WriteAllBytes(_filePath + Guid.NewGuid().ToString() + extension, fileBytes);
    }
}
