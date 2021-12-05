import './App.css';
import ShipCreate from './Components/ShipCreate';
import Ships from './Components/Ships';
import { BrowserRouter, Route, Link } from 'react-router-dom';
import { Routes } from 'react-router';
import "bootstrap/dist/css/bootstrap.min.css";

function App() {
    return (        
        <div>
            <nav className="navbar navbar-expand navbar-dark bg-dark">
                <BrowserRouter>
                    <Link to='./Ships' className="navbar-brand">Ship Dashboard</Link>                                
                    <div className="navbar-nav mr-auto">
                        <li className="nav-item">
                            <Link to={"/ShipCreate"} className="nav-link">
                                Add
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to={"/ShipEdit"} className="nav-link">
                                Edit
                            </Link>
                        </li>
                    </div>
                    <Routes>
                        <Route path='./Ships' element={<Ships />} />
                        <Route path='/ShipCreate' element={<ShipCreate />} />
                        <Route path='/ShipEdit' element={<ShipCreate />} />
                    </Routes>
                </BrowserRouter>
            </nav>
        </div> 
    );
}
export default App;

