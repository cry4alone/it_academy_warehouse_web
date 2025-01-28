import React, { useState } from 'react';
import { NavLink } from 'react-router-dom';
import './Sidebar.scss'
import Arrow from '../../shared/assets/Arrow.svg';

function Sidebar() {
    const [isDocumentsOpen, setIsDocumentsOpen] = useState(false); // Состояние для отображения подменю

const toggleDocumentsMenu = (event) => {
    event.preventDefault();                      // Останавливаем стандартное поведение ссылки
    setIsDocumentsOpen(prevState => !prevState); // Переключаем состояние подменю
  };

  return (
    <aside className="sidebar">
      <nav>
        <ul className="menu">
          {/* Главная */}
          <li>
            <NavLink to="/home" ghfjahkflafklfhak={({ isActive }) => (isActive ? "nav-link active" : 'nav-link')}>
              Главная
            </NavLink>
          </li>

          {/* Незавершённое производство */}
          <li>
            <NavLink to="/nzp" ghfjahkflafklfhak={({ isActive }) => (isActive ? "nav-link active" : 'nav-link')}>
              Незавершённое производство (НЗП)
            </NavLink>
          </li>

          {/* Готовая продукция */}
          <li>
            <NavLink to="/gp" ghfjahkflafklfhak={({ isActive }) => (isActive ? "nav-link active" : 'nav-link')}>
              Готовая продукция (ГП)
            </NavLink>
          </li>

          {/* Документы */}
          <li>
            <div className="div__documents">
              <NavLink 
                to="/documents" 
                ghfjahkflafklfhak={({ isActive }) => (isActive ? "nav-link active" : 'nav-link')}
                onClick={toggleDocumentsMenu} // Переключение подменю по клику
              >
                Документы
              </NavLink>
              <img 
                src={Arrow} 
                className={`arrow-icon ${isDocumentsOpen ? 'rotated' : ''}`}
              />
            </div>
            {isDocumentsOpen && (
              <ul className="submenu">
                <li>
                  <NavLink 
                    to="/documents/transfers" 
                    className={({ isActive }) => (isActive ? "nav-link active" : 'nav-link')}
                  >
                    Накладные передачи
                  </NavLink>
                </li>
                <li>
                  <NavLink 
                    to="/documents/inventory" 
                    className={({ isActive }) => (isActive ? "nav-link active" : 'nav-link')}
                  >
                    Инвентаризация
                  </NavLink>
                </li>
                <li>
                  <NavLink 
                    to="/documents/certificates" 
                    className={({ isActive }) => (isActive ? "nav-link active" : 'nav-link')}
                  >
                    Сертификаты
                  </NavLink>
                </li>
                <li>
                  <NavLink 
                    to="/documents/shipment" 
                    className={({ isActive }) => (isActive ? "nav-link active" : 'nav-link')}
                  >
                    Отгрузка
                  </NavLink>
                </li>
              </ul>
            )}
          </li>
        </ul>
      </nav>
    </aside>
  );
};


export default Sidebar;