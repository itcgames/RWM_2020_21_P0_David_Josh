﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSuite
{
    private Game game;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator AsteroidsMoveDown()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        float initialYPos = asteroid.transform.position.y;
        yield return new WaitForSeconds(0.1f);

        Assert.Less(asteroid.transform.position.y, initialYPos);
    }

    [UnityTest]
    public IEnumerator GameOverOccursOnAsteroidCollision()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = game.GetShip().transform.position;
        yield return new WaitForSeconds(0.1f);

        Assert.True(game.isGameOver);
    }

    [UnityTest]
    public IEnumerator NewGameRestartsGame()
    {
        //1
        game.isGameOver = true;
        game.NewGame();
        //2
        Assert.False(game.isGameOver);
        yield return null;
    }

    [UnityTest]
    public IEnumerator LaserDestroysAsteroid()
    {
        // 1
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetShip().SpawnLaser();
        laser.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        // 2
        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }

    [UnityTest]
    public IEnumerator DestroyedAsteroidRaisesScore()
    {
        // 1
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetShip().SpawnLaser();
        laser.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        // 2
        Assert.AreEqual(game.score, 1);
    }
    [UnityTest]
    public IEnumerator GameScoreEqualZero()
    {
        game.isGameOver = true;
        game.NewGame();
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(game.score, 0);
    }

    [UnityTest]
    public IEnumerator LaserMovesUp()
    {
        //spawn a test laser object and set get its initail pos
        GameObject laser = game.GetShip().SpawnLaser();
        float initialYPos = laser.transform.position.y;
        //wait 0.1 seconds and  check the value is greater eg moving up
        yield return new WaitForSeconds(0.1f);
        Assert.Greater(laser.transform.position.y, initialYPos);
    }
    [UnityTest]
    public IEnumerator MoveShipRight()
    {
        GameObject ship = game.GetShip().gameObject;
        float initialXPos = ship.transform.position.x;
        yield return new WaitForSeconds(0.1f);
        game.GetShip().MoveRight();
        Assert.Greater(ship.transform.position.x, initialXPos);
    }
    [UnityTest]
    public IEnumerator MoveShipLeft()
    {
        GameObject ship = game.GetShip().gameObject;
        float initialXPos = ship.transform.position.x;
        yield return new WaitForSeconds(0.1f);
        game.GetShip().MoveLeft();
        Assert.Less(ship.transform.position.x, initialXPos);
    }
    [UnityTest]
    public IEnumerator SheildSpawn()
    {
        GameObject ship = game.GetShip().gameObject;
        ship.GetComponent<Ship>().setSheild();
        //yield return new WaitForSeconds(0.1f);
        Assert.AreEqual(ship.GetComponent<Ship>().getShieldStatus(), true);
        yield return null;
    }
    [UnityTest]
    public IEnumerator MoveShipUp()
    {
        GameObject ship = game.GetShip().gameObject;
        float initialYPos = ship.transform.position.y;
        yield return new WaitForSeconds(0.1f);
        game.GetShip().MoveUp();
        Assert.Greater(ship.transform.position.y, initialYPos);
    }
    [UnityTest]
    public IEnumerator MoveShipDown()
    {
        GameObject ship = game.GetShip().gameObject;
        float initialYPos = ship.transform.position.y;
        yield return new WaitForSeconds(0.1f);
        game.GetShip().MoveDown();
        Assert.Less(ship.transform.position.y, initialYPos);
    }
}


