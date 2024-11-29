import React, { useEffect, useState } from "react";
import { ICreateCandidateDto, IJob } from "../../types/global.typing";

import TextField from "@mui/material/TextField/TextField";
import FormControl from "@mui/material/FormControl/FormControl";
import Button from "@mui/material/Button/Button";
import InputLabel from "@mui/material/InputLabel/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import Select from "@mui/material/Select/Select";
import { useNavigate } from "react-router-dom";
import httpModule from "../../helpers/http.module";

import "./Candidates.page";

const AddCandidate = () => {
  const redirect = useNavigate();

  const [candidate, setCandidate] = useState<ICreateCandidateDto>({
    firstName: " ",
    lastName: " ",
    email: "",
    phone: "",
    coverLetter: "",
    jobId: "",
  });

  const [jobs, setJobs] = useState<IJob[]>([]);
  const [pdfFile, setPdfFile] = useState<File | null>();

  useEffect(() => {
    httpModule
      .get<IJob[]>("/Job/Get")
      .then((response) => {
        setJobs(response.data);
      })
      .catch((error) => {
        alert("Error");
        console.log(error);
      });
  }, []);

  const handleClickSaveBtn = () => {
        if (
            candidate.firstName === "" ||
            candidate.lastName === "" ||
            candidate.email === "" ||
            candidate.phone === "" ||
            candidate.coverLetter === "" ||
            candidate.jobId === " "
        ) {
          alert("Fill all fields is required");
          return;
        }
          const newCandidateFormData = new FormData();
          newCandidateFormData.append("firstName", candidate.firstName);
          newCandidateFormData.append("lastName", candidate.lastName);
          newCandidateFormData.append("email", candidate.email);
          newCandidateFormData.append("phone", candidate.phone);
          newCandidateFormData.append("coverLetter", candidate.coverLetter);
          newCandidateFormData.append("jobId", candidate.jobId);
    
        httpModule
          .post("/Candidate/Create", newCandidateFormData)
          .then((response) => redirect("/candidates"))
          .catch((error) => console.log(error));
  };
  const handleClickBackBtn = () => {
    redirect("/candidates");
  };

  return (
    <div className="content">
      <div className="add-candidate">
        <h2>Add New Candidate</h2>
        <FormControl fullWidth>
          <InputLabel>Job</InputLabel>
          <Select
            value={candidate.jobId}
            label="Job"
            onChange={(e) =>
              setCandidate({ ...candidate, jobId: e.target.value })
            }
          >
            {jobs.map((item) => (
              <MenuItem key={item.id} value={item.id}>
                {item.title}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        <TextField
          autoComplete="off"
          label="First Name"
          variant="outlined"
          value={candidate.firstName}
          onChange={(e) =>
            setCandidate({ ...candidate, firstName: e.target.value })
          }
        />
        <TextField
          autoComplete="off"
          label="Last Name"
          variant="outlined"
          value={candidate.lastName}
          onChange={(e) =>
            setCandidate({ ...candidate, lastName: e.target.value })
          }
        />
        <TextField
          autoComplete="off"
          label="Email"
          variant="outlined"
          value={candidate.email}
          onChange={(e) =>
            setCandidate({ ...candidate, email: e.target.value })
          }
        />
        <TextField
          autoComplete="off"
          label="Phone"
          variant="outlined"
          value={candidate.phone}
          onChange={(e) =>
            setCandidate({ ...candidate, phone: e.target.value })
          }
        />

        <TextField
          autoComplete="off"
          label="CV"
          variant="outlined"
          value={candidate.coverLetter}
          onChange={(e) =>
            setCandidate({ ...candidate, coverLetter: e.target.value })
          }
        />
        <input
          type="file"
          onChange={(event) =>
            setPdfFile(event.target.files ? event.target.files[0] : null)
          }
        />

        <div className="btns">
          <Button
            variant="outlined"
            color="primary"
            onClick={handleClickSaveBtn}
          >
            Save
          </Button>
          <Button
            variant="outlined"
            color="secondary"
            onClick={handleClickBackBtn}
          >
            Back
          </Button>
        </div>
      </div>
    </div>
  );
};

export default AddCandidate;
