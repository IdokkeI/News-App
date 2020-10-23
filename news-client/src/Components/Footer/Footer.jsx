import React from 'react'
import './Footer.scss'

const Footer = () => {
    return <div className='footer'>
        <div className='footer-container'>
            <div className='footer__copyright'>
                <ul><span>© Сайт разработали:</span>
                    <li>
                        <span>Andrei Zhivotkov</span>
                    </li>
                    <li>
                        <span>Arseni Lamihov</span>
                    </li>
                    <li>
                        <span>Dmitry Gaiduk</span>
                    </li>
                </ul>
            </div>
        </div>
    </div>
}

export default Footer;