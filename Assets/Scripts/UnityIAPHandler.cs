using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.Purchasing;
using UnityEngine.UI;
//
//public class UnityIAPHandler : MonoBehaviour, IStoreListener
public class UnityIAPHandler : MonoBehaviour
{
//	public static UnityIAPHandler instance;
//	private IStoreController m_Controller;
//	private bool m_PurchaseInProgress;
//
//	private string googlePlayPublicKey = "";
//	private string noAdsProductID = "noadsgohigher";
//
//	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
//	{
//		m_Controller = controller;
//	}
//
//	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
//	{
//		Debug.Log("Purchase OK: " + e.purchasedProduct.definition.id);
//		Debug.Log("Receipt: " + e.purchasedProduct.receipt);
//
//		switch(e.purchasedProduct.definition.id) {
//		case "noadsgohigher":
//			//ShopHandler.instance.ShopHolesHandler();
//			break;
//		}
//
//		m_PurchaseInProgress = false;
//
//		return PurchaseProcessingResult.Complete;
//	}
//
//	public void OnPurchaseFailed(Product item, PurchaseFailureReason r)
//	{
//		Debug.Log("Purchase failed: " + item.definition.id);
//		Debug.Log(r);
//
//		m_PurchaseInProgress = false;
//	}
//
//	public void OnInitializeFailed(InitializationFailureReason error)
//	{
//		Debug.Log("Billing failed to initialize!");
//		switch (error)
//		{
//		case InitializationFailureReason.AppNotKnown:
//			Debug.LogError("Is your App correctly uploaded on the relevant publisher console?");
//			//CreditsHandler.instance.ShowStatus("Sorry, We can verify this purchase right now!");
//			break;
//		case InitializationFailureReason.PurchasingUnavailable:
//			// Ask the user if billing is disabled in device settings.
//			//CreditsHandler.instance.ShowStatus("Billing is disabled in your device!");
//			Debug.Log("Billing disabled!");
//			break;
//		case InitializationFailureReason.NoProductsAvailable:
//			// Developer configuration error; check product metadata.
//			//CreditsHandler.instance.ShowStatus("No products available for purchase!");
//			Debug.Log("No products available for purchase!");
//			break;
//		}
//	}
//
//	public void Awake()
//	{
//		instance = this;
//
//		var module = StandardPurchasingModule.Instance();
//		var builder = ConfigurationBuilder.Instance(module);
//		builder.Configure<IGooglePlayConfiguration>().SetPublicKey(googlePlayPublicKey);
//		builder.AddProduct(noAdsProductID, ProductType.NonConsumable);
//		UnityPurchasing.Initialize(this, builder);
//	}
//
//	public void BuyItemAllLevels() {
//		// PurchaseButton
//		if (m_PurchaseInProgress == true) {
//			Debug.Log("IAP not available");
//			return;
//		}
//
//		m_PurchaseInProgress = true;
//		m_Controller.InitiatePurchase("alllevelsminigolfworld"); 
//
//	}
}
