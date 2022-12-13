import React from 'react';
import logo from './logo.svg';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';

import './App.css';
import { Address } from './models';

import AddressList from './components/Address/AddressList';
import AddressCUV from './components/Address/AddressCUV';

import ClientList from './components/Client/ClientList';
import ClientCUV from './components/Client/ClientCUV';
import OrderList from './components/Order/OrderList';
import OrderCUV from './components/Order/OrderCUV';
import PizzaList from './components/Pizza/PizzaList';
import PizzaCUV from './components/Pizza/PizzaCUV';

function App() {
  return (
    <div>
      <BrowserRouter>
        <div className='nav'>
          <Link className='button success' to={'/address'}>Address</Link>
          <Link className='button success' to={'/client'}>Client</Link>
          <Link className='button success' to={'/order'}>Order</Link>
          <Link className='button success' to={'/pizza'}>Pizza</Link>
        </div>
        <div style={{ padding: '20px' }}>
          <Routes>
            <Route path='/address' element={<AddressList />} />
            <Route path='/address/cuv' element={<AddressCUV />} />

            <Route path='/client' element={<ClientList />} />
            <Route path='/client/cuv' element={<ClientCUV />} />

            <Route path='/order' element={<OrderList />} />
            <Route path='/order/cuv' element={<OrderCUV />} />

            <Route path='/pizza' element={<PizzaList />} />
            <Route path='/pizza/cuv' element={<PizzaCUV />} />
          </Routes>
        </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
