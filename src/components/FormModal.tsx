import type { ReactNode } from "react"
import "./FormModal.css"

interface Props{
  open:boolean
  onClose:()=>void
  title:string
  children:ReactNode
}

export default function FormModal({open,onClose,title,children}:Props){

  if(!open) return null

  return(

    <div className="modal-overlay" onClick={onClose}>

      <div
        className="modal"
        onClick={(e)=>e.stopPropagation()}
      >

        <div className="modal-header">

          <h3>{title}</h3>

          <button
            className="modal-close"
            onClick={onClose}
          >
            ✖
          </button>

        </div>

        <div className="modal-body">
          {children}
        </div>

      </div>

    </div>

  )
}