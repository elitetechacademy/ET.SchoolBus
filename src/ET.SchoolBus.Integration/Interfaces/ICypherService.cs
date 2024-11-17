using System;

namespace ET.SchoolBus.Integration.Interfaces;

public interface ICypherService
{
    string Encrypte(string clearText);
    string Decrypte(string encryptedText);
}
