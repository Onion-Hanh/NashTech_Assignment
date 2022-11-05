import React from "react";
import Button from "react-bootstrap/Button";
import Form from "react-bootstrap/Form";
import { useEffect, useState } from "react";
import "../css/Form.css";
import { updateData, getDataById } from "../Services/CategoryAPI";

export default function EditCategory() {
  //get and load data by categoryId
  const [category, setCategory] = useState();
  const[userChoice, setUserChoice]=useState("");
  useEffect(() => {
    loadCategoryById();
  }, []);
  const loadCategoryById = async () => {
    const result = await getDataById(localStorage.getItem("categoryId"));
    setCategory(result.data);
  };
  //update category by id
  const UpdateCategory = async (
    categoryId,
    categoryName,
    categoryDescription
  ) => {
    await updateData(categoryId, categoryName, categoryDescription);
  };
  //handle form submit
  const handleSubmit = (e) => {
    e.preventDefault();
    const category_id = localStorage.getItem("categoryId");
    const category_name = e.target.name.value;
    const category_description = e.target.description.value;
    const category_status=true;
    if (UpdateCategory(category_id, category_name, category_description, category_status)) {
      alert("Cập nhật thành công!");
    } else {
      alert("Cập nhật thất bại!");
    }
  };
  return (
    <div>
      <h3 className="content-label">CẬP NHẬT DANH MỤC</h3>
      {category && (
        <Form className="form" onSubmit={handleSubmit}>
          <Form.Group className="mb-3">
            <Form.Label>Mã danh mục</Form.Label>
            <Form.Control
              type="text"
              placeholder="Tên danh mục..."
              disabled
              value={category.id}
            />
          </Form.Group>
          <Form.Group className="mb-3">
            <Form.Label>Tên danh mục</Form.Label>
            <Form.Control
              name="name"
              type="text"
              placeholder="Tên danh mục..."
              defaultValue={category.name}
            />
          </Form.Group>
          <Form.Group className="mb-3">
            <Form.Label>Mô tả danh mục</Form.Label>
            <Form.Control
              as="textarea"
              name="description"
              placeholder="Mô tả danh mục..."
              style={{ height: "100px" }}
              defaultValue={category.description}
            />
          </Form.Group>
          <Form.Group className="mb-3">
            <Form.Label>Trạng thái</Form.Label>
            <Form.Select aria-label="Default select example" defaultValue={category.status} onChange={(e)=>{setUserChoice(e.target.value)}}>
              <option value="true">Hiện</option>
              <option value="false">Ẩn</option>
            </Form.Select>
          </Form.Group>
          <h1>{userChoice}</h1>
          <Button type="submit" className="btn-primary center">
            Cập nhật danh mục
          </Button>
        </Form>
      )}
    </div>
  );
}
