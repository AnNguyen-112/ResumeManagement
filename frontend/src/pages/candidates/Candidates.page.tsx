import React, { useEffect } from "react";
import { useState } from "react";

import httpModule from "../../helpers/http.module";
import { ICandidate } from "../../types/global.typing";
import { Button, CircularProgress } from "@mui/material";
import { Add } from "@mui/icons-material";
import { redirect, useNavigate } from "react-router-dom";

import "./candidates.scss";

import CandidatesGrid from "../../Component/candidates/CandidatessGrid.component";

const Jobs = () => {
  const navigate = useNavigate();
  const [candidates, setCandidates] = useState<ICandidate[]>([]);
  const [loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    setLoading(true);
    httpModule
      .get<ICandidate[]>("/Candidate/Get")
      .then((response) => {
        setCandidates(response.data);
        setLoading(false);
      })
      .catch((error) => {
        alert("Error");
        console.log(error);
        setLoading(false);
      });
  }, []);

  return (
    <div className="content candidates">
      <div className="heading">
        <h2>Candidates</h2>
        <Button variant="outlined" onClick={() => navigate("/candidates/add")}>
          <Add />
        </Button>
      </div>
      {loading ? (
        <CircularProgress size={100} />
      ) : candidates.length === 0 ? (
        <h1>No Candidate</h1>
      ) : (
        <CandidatesGrid data={candidates} />
      )}
    </div>
  );
};

export default Jobs;
