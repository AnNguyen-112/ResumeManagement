import { Box } from "@mui/material";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import React from "react";
import moment from "moment";
import { IJob } from "../../types/global.typing";

import "./jobs-grid.scss"

const column: GridColDef[] = [
  { field: "id", headerName: "ID", width: 100 },
  { field: "title", headerName: "Title", width: 200 },
  { field: "level", headerName: "Level", width: 150 },
  { field: "companyName", headerName: "Company Name", width: 150 },
  {
    field: "createdAt",
    headerName: "Creation Time",
    width: 150,
    renderCell: (params) => moment(params.row.createdAt).fromNow(),
  },
  { field: "size", headerName: "Size", width: 150 },
  { field: "size", headerName: "Size", width: 150 },
 
];

interface IJobsGridProps {
  data: IJob[];
}

const JobsGrid = ({ data }: IJobsGridProps) => {
  return (
    <Box className="companies-grid">
      <DataGrid
        rows={data}
        columns={column}
        getRowId={(row) => row.id}
        rowHeight={50}
      />
    </Box>
  );
};

export default JobsGrid;
