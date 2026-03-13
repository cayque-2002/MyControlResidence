import { Link } from "react-router-dom";
import { useState } from "react";
import "./navbar.css";

export default function Navbar() {

  const [menuOpen, setMenuOpen] = useState(false);

  return (
    <nav className="navbar">

      <div className="navbar-top">
        <h2 className="logo">MyControlResidence</h2>

        <button
          className="menu-btn"
          onClick={() => setMenuOpen(!menuOpen)}
        >
          ☰
        </button>
      </div>

      <div className={`nav-links ${menuOpen ? "open" : ""}`}>
        <Link to="/">Relatório</Link>
        <Link to="/pessoas">Pessoas</Link>
        <Link to="/categorias">Categorias</Link>
        <Link to="/transacoes">Transações</Link>
      </div>

    </nav>
  );
}