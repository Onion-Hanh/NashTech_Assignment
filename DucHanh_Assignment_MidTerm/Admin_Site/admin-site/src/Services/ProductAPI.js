import axios from "axios";
const getDataUrl = "https://localhost:7262/api/Product/getAllProductsAdmin";
const getProductByNameUrl =
  "https://localhost:7262/api/Product/GetProductsByNameAdmin";
//Get all product
export async function getData() {
  try {
    let result = await axios.get(getDataUrl);
    return result;
  } catch (error) {
    console.log(error);
  }
}
//Get product by name
export async function getProductByName(productName) {
  try {
    let result;
    if (productName === "") {
      result = await axios.get(getDataUrl);
    } else {
      result = await axios.get(getProductByNameUrl + "/" + productName);
    }
    return result;
  } catch (error) {
    console.log(error);
  }
}
