import React from "react";
import logo from "./logo.svg";
import "./App.css";

import { useContext, lazy, Suspense } from "react";
import { ThemeContext } from "./context/theme.context";
import Navbar from "./Component/Navbar/Navbar.component";
import { Routes, Route } from "react-router-dom";
import CustomLinearProgress from "./Component/custom-linear-progress/CustomLinearProgress.component";

const Home = lazy(() => import("./pages/home/Home.page"));

const App = () => {
  const { darkMode } = useContext(ThemeContext);

  const appStyles = darkMode ? "app dark" : "app light";

  return (
    <div className={appStyles}>
      <Navbar/>
      <div className="wrapper">
        <Suspense fallback={<CustomLinearProgress/>}>
          <Routes>
            <Route path="/" element={<Home></Home>}/>
          </Routes>
        </Suspense>
      </div>
    </div>
  );
};
export default App;
