using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoChao_Estado : PlayerBase_Estado
{
    public PlayerNoChao_Estado(PlayerMaquinaDeEstados _contextoAtual, Player_StateFactory _factory)
        : base(_contextoAtual, _factory) {
        eUmEstadoRaiz = true;
        InicializaSubestado();
    }

    public override void InicializaEstado()
    {
        //Garante que o jogador tenha enquanto no ch�o
        ctx.Rb.gravityScale = ctx.GravityScaleIni;

        MostraEstado.Instancia.MostraTextoEstado("No ch�o");
    }

    public override void AtualizaEstado()
    {
        //Enquanto no ch�o, o jogador n�o � afetado por mudan�as no eixo Y
        ctx.CalculoMovimentosY = 0;
        ChecaTrocaDeEstado();
    }

    public override void ChecaTrocaDeEstado()
    {
        if (ctx.PediuPular)
        {
            TrocaEstados(fabrica.Pulo());
        }
        else if (ctx.Agachado)
        {
            TrocaEstados(fabrica.Agachado());
        }
        else if (ctx.PodeSubir)
        {
            TrocaEstados(fabrica.Escada());
        }
        else if (!ctx.NoChao)
        {
            TrocaEstados(fabrica.Caindo());
        }
    }

    public override void FinalizaEstado()
    {
   
    }
    public override void InicializaSubestado()
    {
        if (ctx.PediuDash)
        {
            DefinaSubestado(fabrica.Dash());
           
        }

        if (ctx.InputsX != 0)
        {
            DefinaSubestado(fabrica.Andando());
        }
        else if (ctx.InputsX == 0)
        {
            DefinaSubestado(fabrica.Parado());
        }
    }

}
