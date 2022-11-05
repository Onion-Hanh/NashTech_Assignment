import axios from "axios";
const url = "https://localhost:7262/api/Category";

export async function getData() {
  try {
    let result = await axios.get(url + "/getAllCategoriesAdmin");
    return result;
  } catch (error) {
    console.log(error);
  }
}
export async function getDataById(categoryId) {
  try {
    let result = await axios.get(url + "/getCategoryByIdAdmin/" + categoryId);
    return result;
  } catch (error) {
    console.log(error);
  }
}
export async function addData(categoryName, categoyDescription) {
  try {
    let category = {
      name: categoryName,
      description: categoyDescription,
      createDate: "",
    };
    if (await axios.post(url, category)) {
      console.log("true");
    } else {
      console.log("false");
    }
  } catch (error) {
    console.log(error);
  }
}

export async function updateData(categoryId, categoryName, categoyDescription, categoryStatus) {
  try {
    let category = {
      id: categoryId,
      name: categoryName,
      description: categoyDescription,
      createDate: "",
      status: categoryStatus,
    };
    if (await axios.put(url, category)) {
      console.log("true");
    } else {
      console.log("false");
    }
  } catch (error) {
    console.log(error);
  }
}
