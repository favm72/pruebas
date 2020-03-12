using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pruebau.Model
{
	public class SecurityDA
	{
		private static SymmetricAlgorithm G_sEncriptador;

		private static readonly byte[] G_sKEY = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
											11, 12, 13, 14, 15, 16, 17, 18,
											19, 20, 21, 22, 23, 24 };
		private static readonly byte[] G_sIV = { 8, 7, 6, 5, 4, 3, 2, 1 };

		public static string Encrypt(string cadena)
		{
			ICryptoTransform mTransformacion = default(ICryptoTransform);
			MemoryStream mMemoryStream = default(MemoryStream);
			CryptoStream mCriptografia = default(CryptoStream);
			byte[] mCadenaBytes = null;
			string mEncriptado = null;

			G_sEncriptador = new TripleDESCryptoServiceProvider();

			if (((G_sKEY.Length > 0) & (G_sIV.Length > 0)))
			{
				try
				{
					mTransformacion = G_sEncriptador.CreateEncryptor(G_sKEY, G_sIV);
					mCadenaBytes = Encoding.UTF8.GetBytes(cadena);

					mMemoryStream = new MemoryStream();
					mCriptografia = new CryptoStream(mMemoryStream, mTransformacion, CryptoStreamMode.Write);
					mCriptografia.Write(mCadenaBytes, 0, mCadenaBytes.Length);
					mCriptografia.FlushFinalBlock();

					mCriptografia.Close();

					mEncriptado = Convert.ToBase64String(mMemoryStream.ToArray());
				}
				catch (CryptographicException ex)
				{
					return ("Error: " + ex.Message);
				}
			}
			else
			{
				return "Error: No se pudo conseguir la Clave y el IV";
			}

			return mEncriptado;
		}

		public static string Decrypt(string cadena)
		{

			ICryptoTransform mTransformacion;
			MemoryStream mMemoryStream;
			CryptoStream mCriptografia;
			byte[] mCadenaBytes = null;
			string mDesencriptado;

			G_sEncriptador = new TripleDESCryptoServiceProvider();
			if ((G_sKEY.Length > 0) && (G_sIV.Length > 0))
			{
				try
				{
					mTransformacion = G_sEncriptador.CreateDecryptor(G_sKEY, G_sIV);
					mCadenaBytes = Convert.FromBase64String(cadena);
					mMemoryStream = new MemoryStream();
					mCriptografia = new CryptoStream(mMemoryStream, mTransformacion, CryptoStreamMode.Write);
					mCriptografia.Write(mCadenaBytes, 0, mCadenaBytes.Length);
					mCriptografia.FlushFinalBlock();
					mCriptografia.Close();
					mDesencriptado = Encoding.UTF8.GetString(mMemoryStream.ToArray());
				}
				catch (Exception ex)
				{
					return ("Error: " + ex.Message);
				}
			}
			else
			{
				return "Error: No se pudo conseguir la Clave y el IV";
			}
			return mDesencriptado;
		}
	}
}
