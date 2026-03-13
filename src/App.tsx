import { BrowserRouter, Routes, Route } from "react-router-dom";

import { ToastContainer } from "react-toastify"
import "react-toastify/dist/ReactToastify.css"

import Navbar from "./components/Navbar";

import ReportPage from "./pages/ReportPage";
import PessoaPage from "./pages/PessoaPage";
import CategoriaPage from "./pages/CategoriaPage";
import TransacaoPage from "./pages/TransacaoPage";

function App() {
  return (
    <BrowserRouter>

      <div style={{ minWidth: "100vw", width: "100%", minHeight:"95vh", height: "100%" }}>
        <Navbar />

        <div className="page-container">

          <ToastContainer
              position="top-right"
              autoClose={3000}
              hideProgressBar={false}
              newestOnTop
              closeOnClick
              pauseOnHover
              theme="dark"
            />

          <Routes>
            <Route path="/" element={<ReportPage />} />
            <Route path="/pessoas" element={<PessoaPage />} />
            <Route path="/categorias" element={<CategoriaPage />} />
            <Route path="/transacoes" element={<TransacaoPage />} />
          </Routes>
        </div>

      </div>

    </BrowserRouter>
  );
}

export default App;