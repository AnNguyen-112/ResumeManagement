import React, { useEffect } from "react";
import { useState } from "react";

import httpModule from "../../helpers/http.module";
import { ICompany } from "../../types/global.typing";
import { Button, CircularProgress } from "@mui/material";
import { Add } from "@mui/icons-material";
import { redirect, useNavigate } from "react-router-dom";
import CompaniesGrid from "../../Component/companies/CompaniesGrid.component";

import "./companies.scss"

const Companies = () => {
  const navigate = useNavigate();
  const [companies, setCompanies] = useState<ICompany[]>([]);
  const [loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    setLoading(true);
    httpModule
      .get<ICompany[]>("/Company/Get")
      .then((response) => {
        setCompanies(response.data);
        setLoading(false);
      })
      .catch((error) => {
        alert("Error");
        console.log(error);
        setLoading(false);
      });
  }, []);

  console.log(companies);

  return (
    <div className="content companies">
      <div className="heading">
        <h2>Companies</h2>
        <Button variant="outlined" onClick={() => navigate("/companies/add")}>
          <Add />
        </Button>
      </div>
      {
        loading ? <CircularProgress size={100}/> : companies.length ===0 ? <h1>NoCompany</h1> : <CompaniesGrid  data={companies}/>
      }
    </div>
  );
};

export default Companies;
